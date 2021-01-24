    public class ChromeDriverEx : ChromeDriver
    {
        private const string SendChromeCommandWithResult = "sendChromeCommandWithResponse";
        private const string SendChromeCommandWithResultUrlTemplate = "/session/{sessionId}/chromium/send_command_and_get_result";
        public ChromeDriverEx(string chromeDriverDirectory, ChromeOptions options)
            : base(chromeDriverDirectory, options)
        {
            CommandInfo commandInfoToAdd = new CommandInfo(CommandInfo.PostCommand, SendChromeCommandWithResultUrlTemplate);
            this.CommandExecutor.CommandInfoRepository.TryAddCommand(SendChromeCommandWithResult, commandInfoToAdd);
        }
        public Screenshot GetFullPageScreenshot()
        {
            // Evaluate this only to get the object that the
            // Emulation.setDeviceMetricsOverride command will expect.
            // Note that we can use the already existing ExecuteChromeCommand
            // method to set and clear the device metrics, because there's no
            // return value that we care about.
            string metricsScript = @"({
    width: Math.max(window.innerWidth,document.body.scrollWidth,document.documentElement.scrollWidth)|0,
    height: Math.max(window.innerHeight,document.body.scrollHeight,document.documentElement.scrollHeight)|0,
    deviceScaleFactor: window.devicePixelRatio || 1,
    mobile: typeof window.orientation !== 'undefined'
    })";
            Dictionary<string, object> metrics = this.EvaluateDevToolsScript(metricsScript);
            this.ExecuteChromeCommand("Emulation.setDeviceMetricsOverride", metrics);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["format"] = "png";
            parameters["fromSurface"] = true;
            object screenshotObject = this.ExecuteChromeCommandWithResult("Page.captureScreenshot", parameters);
            Dictionary<string, object> screenshotResult = screenshotObject as Dictionary<string, object>;
            string screenshotData = screenshotResult["data"] as string;
            this.ExecuteChromeCommand("Emulation.clearDeviceMetricsOverride", new Dictionary<string, object>());
            Screenshot screenshot = new Screenshot(screenshotData);
            return screenshot;
        }
        public object ExecuteChromeCommandWithResult(string commandName, Dictionary<string, object> commandParameters)
        {
            if (commandName == null)
            {
                throw new ArgumentNullException("commandName", "commandName must not be null");
            }
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["cmd"] = commandName;
            parameters["params"] = commandParameters;
            Response response = this.Execute(SendChromeCommandWithResult, parameters);
            return response.Value;
        }
        private Dictionary<string, object> EvaluateDevToolsScript(string scriptToEvaluate)
        {
            // This code is predicated on knowing the structure of the returned
            // object as the result. In this case, we know that the object returned
            // has a "result" property which contains the actual value of the evaluated
            // script, and we expect the value of that "result" property to be an object
            // with a "value" property. Moreover, we are assuming the result will be
            // an "object" type (which translates to a C# Dictionary<string, object>).
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["returnByValue"] = true;
            parameters["expression"] = scriptToEvaluate;
            object evaluateResultObject = this.ExecuteChromeCommandWithResult("Runtime.evaluate", parameters);
            Dictionary<string, object> evaluateResultDictionary = evaluateResultObject as Dictionary<string, object>;
            Dictionary<string, object> evaluateResult = evaluateResultDictionary["result"] as Dictionary<string, object>;
            // If we wanted to make this actually robust, we'd check the "type" property
            // of the result object before blindly casting to a dictionary.
            Dictionary<string, object> evaluateValue = evaluateResult["value"] as Dictionary<string, object>;
            return evaluateValue;
        }
    }
