Assuming userRoles is empty before the foreach loop:
        userRoles.AddRange(CheckBoxRepeater.Where(x => x.Checked));
        if (userRoles.Count > 0)
        {
            //Do something else
        }
