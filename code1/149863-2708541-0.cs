        public UserInformation GetUserInformation()
        {
            UserInformation userInformation = new UserInformation();
            updatePersonalDetails(userInformation);
            updateMachineDetails(userInformation);
            return userInformation;
        }
        private void updatePersonalDetails(UserInformation userInformation)
        {
        }
        private void updateMachineDetails(UserInformation userInformation)
        {
        }
