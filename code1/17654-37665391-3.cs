            var xDoc = XElement.Parse(xml);
            var nameElement = xDoc.Element("Name");
            var ageElement = xDoc.Element("Age");
            var isContentElement = xDoc.Element("IsContent");
            var birthDayElement = xDoc.Element("BirthDay");
            string name = null;
            if (nameElement != null)
            {
                name = nameElement.Value;
            }
            var age = 0;
            if (ageElement != null)
            {
                age = int.Parse(ageElement.Value);
            }
            var isContent = false;
            if (isContentElement != null)
            {
                isContent = bool.Parse(isContentElement.Value);
            }
            var birthDay = new DateTime();
            if (birthDayElement != null)
            {
                birthDay = DateTime.ParseExact(birthDayElement.Value, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            }
