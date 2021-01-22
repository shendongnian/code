            AttributeCollection ac  = TypeDescriptor.GetAttributes(yourObj);
            foreach (var att in ac)
            {
                //DataEntityAttribute  -- ur attribute class name
                DataEntityAttribute da = att as DataEntityAttribute ;
                Console.WriteLine(da.field1);  //initially it shows MESSAGE_STAGING
                da.field1= "Test_Message_Staging";  
             }
             //Check the changed value
            AttributeCollection acc = TypeDescriptor.GetAttributes(yourObj);
            foreach (var att in ac)
            {
                DataEntityAttribute da = att as DataEntityAttribute ;
                Console.WriteLine(da.field1); //now it shows Test_Message_Staging
            }
