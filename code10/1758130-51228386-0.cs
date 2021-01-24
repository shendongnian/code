    public class PuffAndStuff
            {
                private String puff = "";
                //Naming viloation - changed puff to Puff
                public string Puff { get => puff; set => Puff = value; }
            }
    
     private void OPCode()
            {
                StreamReader reader = File.OpenText(@"D:\\SampleText.txt");
                string check = reader.ReadToEnd();
                List<PuffAndStuff> lstPuff = new List<PuffAndStuff>();
                string[] arrayCheck = Regex.Split(check, @"Puff[0-9]\r\n");
                foreach(string s in arrayCheck)
                {
                    lstPuff.Add(new PuffAndStuff { Puff = s });
                }
                lstPuff[0].Puff = arrayCheck[1] + arrayCheck[2];
                Console.WriteLine("Segment 1:\r\n" + lstPuff[0].Puff);
                Console.WriteLine("Segment 2:\r\n" + arrayCheck[3] + arrayCheck[4]);
            }
