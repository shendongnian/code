            string fullName = "John Doe";
            string[] nameParts = fullName.Split(' ');
            string firstName = nameParts[0];
            string lastName = string.Empty;
            if (nameParts.Length == 2)
            {
                lastName = nameParts[1];
            }
            else
            {
                for (int i = 1; i < nameParts.Length; i++)
                {
                    lastName += nameParts[i];
                }
            }
            string reversedName = lastName + ", " + firstName; // Cory Charlton rocks ;-)
