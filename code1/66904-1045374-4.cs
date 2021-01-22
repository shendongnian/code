    routes.MapRoute("AssignRemove",
                    "Items/Assign/{itemId}",
                    new { controller = "Items", action = "Assign" },
                    new { itemId = "\d+" }
                    );
    routes.MapRoute("AssignRemovePretty",
                    "Items/Assign/{parentName}/{itemName}",
                    new { controller = "Items", action = "AssignRemovePretty" },
                    new { parentName = "\w+", itemName = "\w+" }
                    );
