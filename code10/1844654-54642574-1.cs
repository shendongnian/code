            if (string.IsNullOrEmpty(member.LastName))
            {
                return $"{member.FirstName}".Trim();
            }
            else
            {
                return $"{member.LastName} {member.FirstName}".Trim();
            }
