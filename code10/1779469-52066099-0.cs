    Word.Range rng = doc.Content;
    rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    Word.Template objTmpl = (Word.Template) doc.get_AttachedTemplate(); // NormalTemplate
    Word.BuildingBlock objBB = objTmpl.BuildingBlockEntries.Item("TestCCwithActiveX");
    objBB.Insert(rng, true);
    rng = doc.Content;
    rng.Collapse(Word.WdCollapseDirection.wdCollapseEnd);
    Word.BuildingBlock objBB2 = objTmpl.BuildingBlockTypes.Item(Word.WdBuildingBlockTypes.wdTypeAutoText).Categories.Item("Test").BuildingBlocks.Item("test heading");
    objBB2.Insert(rng, true);
