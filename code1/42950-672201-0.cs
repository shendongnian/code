    UpdateEmailResponse updateResponse =(UpdateEmailResponse) updateRequest.SendRequest();
    try
    {
        if (updateResponse.Success)
        {
            Console.WriteLine(String.Format("Update Succsesful.  ListID:{0}  Email:{2}  ID:{1}", pref.ListID, pref.Email, pref.ID));
            continue;
        }
        Console.WriteLine( String.Format("Update Unsuccessful.  ListID:{0}  Email:{2}  ID:{1}\n", pref.ListID, pref.Email, pref.ID));
        Console.WriteLine(String.Format("Error:{0}", updateResponse.ErrorMessage));
    }
    finally
    {
        updateResponse.Dispose();
    }
