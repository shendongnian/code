        private List<SelectListItem> GetAccounts(User user)
        {
            var items = new List<SelectListItem>();
            foreach (Account account in user.Accounts)
            {
                var item = new SelectListItem();
                item.Text = account.Name;
                item.Value = account.AccountId.ToString();
                if (ActiveAccount == account.AccountId)
                    item.Selected = true;
                items.Add(item);
            }
            return items;
        }
