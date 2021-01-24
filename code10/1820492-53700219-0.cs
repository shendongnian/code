    foreach (PropertyInfo pi1 in o1.GetType().GetProperties())
    {
        if (pi.Name = "ModelB") // or some other criterion
        {
            o2 = pi1.GetValue(o1);
            foreach (PropertyInfo pi2 in o2.GetType().GetProperties())
            {
                if (pi.Name = "ModelC") // or some other criterion
                {
                    o3 = pi1.GetValue(o2);
                    // and so on
                }
            }
        }
    }
