        [Test]
        public void IsNumberTest()
        {
            var numberLikes = new[] { UnicodeCategory.DecimalDigitNumber, UnicodeCategory.OtherNumber, UnicodeCategory.LetterNumber };
            for (var i = 0; i < 20000; i++)
            {
                var c = Char.ConvertFromUtf32(i).ToCharArray()[0];
                if (numberLikes.Contains(Char.GetUnicodeCategory(c)))
                {
                    File.AppendAllText("IsNumberLike.txt", string.Format("{0},{1},{2},&#{3};,{4},{5}\n", i, c, Char.GetUnicodeCategory(c), i, Char.IsNumber(c), Char.IsDigit(c)));
                }
            }
        }
