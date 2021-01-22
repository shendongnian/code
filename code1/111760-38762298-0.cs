    public static IList<Letter> GetDepartmentLetters(int departmentId)
        {
            IEnumerable<Letter> allDepartmentLetters = from allLetter in LetterService.GetAllLetters()
                join allUser in UserService.GetAllUsers() on allLetter.EmployeeID equals allUser.ID into usersGroub
                from user in usersGroub.DefaultIfEmpty()
                join allDepartment in DepartmentService.GetAllDepartments() on user.DepartmentID equals allDepartment.ID
                where allDepartment.ID == departmentId
                select allLetter;
            return allDepartmentLetters.ToArray();
        }
