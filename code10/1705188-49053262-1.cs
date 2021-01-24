    var badPractice = new BadPractice();
    if (...)
    {
        badPractice.PartTimeProperty = ...;
    }
    else
    {
        badPractice.FullTimeProperty = ...;
    }
    return View(badPractice);
