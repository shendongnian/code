    static ActivityBuilder CreateTask1()
        {
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("User_Name", new InArgument<string>());
            var res = new ActivityBuilder();
            res.Name = "Task1";
            foreach (var item in properties)
            {
                res.Properties.Add(new DynamicActivityProperty { Name = item.Key, Type = item.Value.GetType(), Value = item.Value });
            }
            Sequence c = new Sequence();
            c.Activities.Add(new WriteLine { Text = new VisualBasicValue<string> { ExpressionText = "\"Hello \" + User_Name" } });
            res.Implementation = c;
            return res;
        }
