    foreach (CheckBox item in FriendCheckboxList)
    {
        if (item.Checked)
        {
            string request = string1 +
                string2 +
                string3 +
                .
                .
                .
               stringLast;
            SendRequest(request);
        }
    }
