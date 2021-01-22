        public UserInformation GetUserInformation()
        {
            UserInformation userInformation = new UserInformation();
            updatePersonalDetails(userInformation);
            updateMachineDetails(userInformation);
            return userInformation;
        }
        private void updatePersonalDetails(UserInformation userInformation)
        {
            userInformation.FirstName = "Sergio";
            userInformation.LastName = "Tapia";
         }
        private void updateMachineDetails(UserInformation userInformation)
        {
            userInformation.MachineName = "Foobar";
        }
