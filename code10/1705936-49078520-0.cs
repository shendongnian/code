    var ans = myTemplateSelections.Select(aTemplate => new Section {
            SectionName = aTemplate.SectionName,
            MyItems = aTemplate.MyTemplateItems.Select(ti => new MyItem {
                ItemName = ti.ItemName,
                ItemText = ti.ItemText //,
                // ItemValue = ???
            }).ToList();
        };
