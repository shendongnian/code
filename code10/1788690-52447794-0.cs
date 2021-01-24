    PrincipalSearchResult<Principal> groups = UserPrincipal.Current.GetGroups();
            IEnumerable<string> groupNames = groups.Select(x => x.SamAccountName);
            if (!groupNames.Contains("ta_admins"))
            {
                Response.Redirect("~/AccessDenied.aspx");
            }
        }
