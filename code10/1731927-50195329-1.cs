        for(int i = 0; i <= acc.Items.Count - 1; i++)
        {
            if(backgroundWorker2.CancellationPending == true)
            {
                e.Cancel = true;
                break;
            }
            else
            {
                int a_copy_of_i = i;
                t = new Thread(() => verify_bots(acc.Items[a_copy_of_i].ToString().Split(':')[0], acc.Items[a_copy_of_i].ToString().Split(':')[1]));
                t.Start();
            }
        }
