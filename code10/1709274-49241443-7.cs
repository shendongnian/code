            //listPrincipalNoNull = listPrincipalSearchResult.Where(item => item.Name != null).ToList();
            if (groupPrincipal != null) {
                foreach (Principal principal in listPrincipalSearchResult) {
                    listGroupMemberGuid.Add(((DirectoryEntry)principal.GetUnderlyingObject()).Guid);
                }
            }
