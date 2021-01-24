    void CheckUser()
        {
    
            
            reference.Child("Stars").Child("Users")
                .GetValueAsync().ContinueWith(task =>
                {
                    if (task.IsFaulted || task.IsCanceled)
                    {
                        info.text = "Verifique a Internet e tente de novo";
                    }
                    else if (task.IsCompleted)
                    {
    
                        //info.text = task.Result.ToString();
                        IDictionary snapshot = (IDictionary) task.Result.Value;
    
                        
    
                        bool snap = false;
                        if (snapshot[login]!= null)
                        {
                            snap = true;
                        }
                        
                        Debug.Log(snap.ToString());
    
    
                        if (snap)
                        {
                            info.text = "login existente, selecione outro sff";
                        }
                        
                        else
                        {
                            //info.text = "falha 4 ";
                            writeLogin();
                        }
                        // Do something with snapshot...
                    }
                    else
                    {
                        info.text = "Verifique a Internet e tente de novo";
                    }
                });
        }
