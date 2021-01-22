    /// <summary>
    /// Catch exceptions of tests and save them in <see cref="TestBase"/> under TestContext.Properties. This is done since MSTEST does not supply any mechanism to catch tests exceptions.
    /// </summary>
    [SerializableAttribute]
    public class CodedTestsExceptionsHandlingAop : OnExceptionAspect
    {
        /// <summary>
        /// The name of the property that will be added to the test context properties object.
        /// </summary>
        public const string FailureExceptionProerty = "FailureException";
        /// <summary>
        /// Save the exception in a <see cref="TestBase"/> and rethrow.
        /// </summary>
        /// <param name="args"></param>
        public override void OnException(MethodExecutionArgs args)
        {
            var testBase = (Framework.TestBase) args.Instance;//The instance running the test inherits from TestBase.
            testBase.TestContext.Properties.Add("FailureException", args.Exception);
            args.FlowBehavior = FlowBehavior.RethrowException;
        }
        /// <summary>
        /// Make sure only test methods will get this AOP.
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public override bool CompileTimeValidate(MethodBase method)
        {
            if (method.IsDefined(typeof(TestMethodAttribute)))
                return true;
            return false;
        }
    }
