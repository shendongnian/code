    //remove the fields obsValue and obs, and use local variables instead
    //private List<string> listObs = new List<string>();
    //private string obs = null;
    public List<string> obsValue
    {
        get
        {
            //create a new list everytime the getter of this member gets called
            var listObs = new List<string>();
            foreach (DataGridViewRow row in dgv_uc.Rows)
            {
                //declare obs here since we only use it here
                var obs = row.Cells["Observed(Sec)"].Value.ToString();
                listObs.Add(obs);
            }
            return listObs;
        }
    }
