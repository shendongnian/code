    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    
        public class RandomCode
        {
    
            //string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            //string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            //string numbers = "1234567890";
    
            //string characters = numbers;
            string characters = "1234567890";
            //if (rbType.SelectedItem.Value == "1")
            //{
            //characters += alphabets + small_alphabets + numbers;
            //characters += numbers;
            //}
            //int length = int.Parse(ddlLength.SelectedItem.Value);
            public string Random()
            {
                int length = 5;
                string otp = string.Empty;
                for (int i = 0; i < length; i++)
                {
                    string character = string.Empty;
                    do
                    {
                        //int index = new Random().Next(0, characters.Length);
                        int index = new Random().Next(0, 5);
                        character = characters.ToCharArray()[index].ToString();
                    } while (otp.IndexOf(character) != -1);
    
                    otp += character;
                }
                //Option to assign here txtRandomCode.Text or out side
                //txtRandomCode.Text = otp; 
                return otp;
            }
    
    
        }
        //outside
        /*
         var r = new RandomCode ();
         txtRandomCode.Text = r.Random()
         */
