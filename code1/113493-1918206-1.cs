    using (Form2 f2 = new Form2())
    {
        f2.Show();
        f2.Update();
    
        System.Threading.Thread.Sleep(2500);
    } // f2 is closed and disposed here
