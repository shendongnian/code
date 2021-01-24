    private void btnDoAllTask_Click(object sender, EventArgs e)
    {
        int count = 0;
        // run 5 times
        while(count < 5)
        {
            count++;
            MyUsername("username" + count.ToString());
        }
    }
