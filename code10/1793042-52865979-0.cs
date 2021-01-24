    static RenderFragment MyFragment = build =>
        {
            for (int i = 0; i < alignment.FlawList.Count; i++)
            {
                build.OpenElement(i + 101, "button"); //Open Element
                build.AddAttribute(i + 101, "style",
                    $"background-color:{alignment.ReturnColor(i)}");
                build.AddAttribute(i + 101, "onclick", ChangeArrow(i)); // Assign Func to the onclick Attribute
                build.AddContent(i + 101, $"{alignment.FlawList[i]} {i}");
                build.CloseComponent(); //Making sure to close Element
            }
        };    
