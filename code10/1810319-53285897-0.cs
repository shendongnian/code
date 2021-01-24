      public class ReflectCmpare
        {
            public PropertyInfo PropertyInfo { get; set; }
            public dynamic Value { get; set; }
        }
        public Cat GetBestCat(List<Cat> listOfCats, List<ReflectCmpare> catParamsToCompare, List<ReflectCmpare> kittensParamsToCompare)
        {
            var bestScore = 0;
            var ret = listOfCats[0];
            foreach (var cat in listOfCats)
            {
                var score = catParamsToCompare.Sum(param => param.PropertyInfo.GetValue(cat, null) == param.Value ? 1 : 0);
                foreach (var baby in cat.Babys)
                {
                    score+= kittensParamsToCompare.Sum(param => param.PropertyInfo.GetValue(baby, null) == param.Value ? 1 : 0);
                }
                if (score <= bestScore) continue;
                bestScore = score;
                ret = cat;
            }
            return ret;
        }
