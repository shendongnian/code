    public Cat GetBestCat(List<Cat> listOfCats, string name , int? age , bool? gender, string race ,string babyName,int? babyAge,bool? babyGender )
        {
            var ret = listOfCats[0];
            var highestScore = 0;
            foreach (var cat in listOfCats)
            {
                var score = 0;
                score += name != null && cat.Name.Equals(name) ? 1 : 0;
                score += age.HasValue && cat.Age.Equals(age.Value) ? 1 : 0;
                score += gender.HasValue && cat.Gender.Equals(gender.Value) ? 1 : 0;
                score += race != null && cat.Race.Equals(race) ? 1 : 0;
                score += name != null && cat.Name.Equals(name) ? 1 : 0;
                score += cat.Babys
                    .Where(k => babyName==null || k.Name.Equals(babyName))
                    .Where(k => !babyAge.HasValue || k.Age.Equals(babyAge.Value))
                    .Any(k => !babyGender.HasValue || k.Gender.Equals(babyGender.Value))?1:0;
                if (score <= highestScore) continue;
                highestScore = score;
                ret = cat;
            }
            return ret;
        }
