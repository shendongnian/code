    Actions action = new Actions(_driver);
    action.DragAndDrop(SortableListOneFifth, SortableListTwoForth).Perform();
    List<IWebElement> sortableListOne = _driver.FindElements(By.XPath(@"//*[@id='sortable1']/li")).ToList();
    List<IWebElement> sortableListTwo = _driver.FindElements(By.XPath(@"//*[@id='sortable2']/li")).ToList();
    var list1 = _sortPage.SortableListOne.Count;
    var list2 = _sortPage.SortableListTwo.Count;
    list1.Should().NotBe(list2);
