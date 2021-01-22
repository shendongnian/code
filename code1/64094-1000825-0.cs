    string[] allToAddresses = to.Split(";,".ToCharArray(),
                                     StringSplitOptions.RemoveEmptyEntries)
    foreach (string toAddress in allToAddresses)
        {
            try
            {
                message.To.Add(toAddress);
            }
            catch (Exception)
            {
                //do nothing, illformed address. screw it.
            }
        }
