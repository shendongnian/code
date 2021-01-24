    var test1 = IsLegalUnicode("abcdeàèéìòù"); // true
    var test2 = IsLegalUnicode("⭐ White Medium Star"); // true, Unicode 5.1
    var test3 = IsLegalUnicode("\uFF00"); // false, undefined BMP UTF-16 unicode
    var test4 = IsLegalUnicode(""[0] + "X"); // false, unpaired high surrogate pair
    var test5 = IsLegalUnicode(""[1] + "X"); // false, unpaired low surrogate pair
    var test6 = IsLegalUnicode(" Grinning Face"); // false, Unicode 6.1
