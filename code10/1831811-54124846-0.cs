        private async void PNationalNo_KeyUp(object sender, KeyEventArgs e)
            {            
                string Ptext = Textbox.text;
                string ResposeDataP  = ""; 
                await Task.Run(() =>
                {
                    ResposeDataP = RunAsyncGetOnePatient(Ptext, GV.AccountID).Result;
                });
                if (Textbox.text != Ptext)
                {
                    return;
                }
                Patient1 = JsonConvert.DeserializeObject<PatientM>(ResposeDataP);
                if (Patient1 != null)
                {
                    WrongMsg1.Text = "user '" + Patient1 .PatientFullName.ToLower() + "' have this ID number!";
                }
                else
                {
                    WrongMsg1.Text = "there is no user have this ID!!";
                }
        }
