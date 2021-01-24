    public string MethodName(ref rdServerObjects rdObjects)
    {
            RootObject preJsonData = new RootObject();
    
            List<Input> inputs = new List<Input>();
            Input input = new Input();
            preJsonData.username = "xxxx";
            preJsonData.password = "yyyy";
            input.name = "cccc";
            inputs.Add(input);
            input = new Input();    //Add this line to keep from overwriting first
            input.name = "dddd";
            inputs.Add(input);
    
            //THIS LINE
            preJsonData.inputs = inputs;
    
            string postJsonData = JsonConvert.SerializeObject(preJsonData);
            //string postJsonData = new JavaScriptSerializer().Serialize(preJsonData);
            return postJsonData;
        }
    }
