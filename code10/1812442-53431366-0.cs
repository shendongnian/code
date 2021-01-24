     if (word.Contains("end") == true)
                    {
                        string millis = "1000";
                        string pauses = string.Concat('"' + millis + "ms\"");
                        //create SSML string to be read automatically by the speech 
    synthesizer
                        string endfile;
                        endfile = "<speak version=\"1.0\"";
                        endfile += " xmlns=\"http://www.w3.org/2001/10/synthesis \"";
                        endfile += " xml:lang=\"ru-RU\">";
                        endfile += "до свидания";
                        endfile += "<break time= ";
                        endfile += pauses;
                        endfile += " />";
                        endfile += "</speak>";
                        //Write russian word to console
                        Console.WriteLine(endfile);
                        //speak russian word
                        synthR.Rate = -6;
                        synthR.SpeakSsml(endfile);
                        //Test for debug of end file loss
                        Console.WriteLine(
                        "Capacity = {0}, Length = {1}, Position = {2}\n",
                         ms.Capacity.ToString(),
                         ms.Length.ToString(),
                         ms.Position.ToString());
                        synthR.Rate = -4;
                        // repeat russian word
                        synthR.SpeakSsml(endfile);
                        //Test for debug of end file loss
                        Console.WriteLine(
                        "Capacity = {0}, Length = {1}, Position = {2}\n",
                         ms.Capacity.ToString(),
                         ms.Length.ToString(),
                         ms.Position.ToString());
                    }
