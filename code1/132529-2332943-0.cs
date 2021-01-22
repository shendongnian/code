double MyPos = 19.95, MyNeg = -19.95, MyZero = 0.0;
string MyString = MyPos.ToString("$#,##0.00;($#,##0.00);Zero");
// In the U.S. English culture, MyString has the value: $19.95.
MyString = MyNeg.ToString("$#,##0.00;($#,##0.00);Zero");
// In the U.S. English culture, MyString has the value: ($19.95).
// The minus sign is omitted by default.
MyString = MyZero.ToString("$#,##0.00;($#,##0.00);Zero");
// In the U.S. English culture, MyString has the value: Zero.
