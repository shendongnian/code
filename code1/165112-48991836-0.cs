    Dictionary<int, string> userListDictionary = new Dictionary<int, string>();
            foreach (var user in users)
            {
                userListDictionary.Add(user.Id,user.Name);
            }
            
            cmbUser.DataSource = new BindingSource(userListDictionary, null);
            cmbUser.DisplayMember = "Value";
            cmbUser.ValueMember = "Key";
