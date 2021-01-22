    myNamespace = outLookApp.GetNamespace("MAPI");
    if (myNamespace.Categories["liveMeeting"] == null)
    {
      myNamespace.Categories.Add("liveMeeting", OlCategoryColor.olCategoryColorDarkRed, OlCategoryShortcutKey.olCategoryShortcutKeyNone);
    }
    newEvent.Categories = "liveMeeting";
