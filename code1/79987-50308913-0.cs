          public static string ToGender(this Gender enumValue)
            {
                switch (enumValue)
                {
                    case Gender.Female:
                        return "Female";
                    case Gender.Male:
                        return "Male";
                    default:
                        return null;
                }
            }
