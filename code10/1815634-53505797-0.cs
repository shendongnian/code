    string[] phoneNumber = lineContainingNumber.Split('>');
            foreach (string phoneNumberEntity in phoneNumber)
            {
                if (Regex.IsMatch(phoneNumberEntity.Replace(@"</span", ""), @"\d{3}-\d{3}-\d{4}"))
                {
                    Console.WriteLine(phoneNumberEntity.Replace(@"</span", ""));
                    break;
                }
            }
