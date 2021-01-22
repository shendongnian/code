    var menuItems =
        from menuItem in Menu.All()
            where menuItem.Visible
                and (
                    menuItem.WebPages.Contains(
                        webPage => webPage.Roles.Contains(
                            "role"
                        )
                    )
                    or menuItem.PageIsNull
                )
            select menuItem;
