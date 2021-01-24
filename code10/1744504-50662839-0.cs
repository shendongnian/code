    public Task SaveClient(UserViewModel viewModel)
        {
            try
            {
                var applicationUser = _userManager.FindByIdAsync(viewModel.Id).Result;
                if (applicationUser == null || applicationUser.Deleted) throw new Exception("User not found. ");
                var role = _userManager.GetRolesAsync(applicationUser).Result.FirstOrDefault();
                if (role != viewModel.Role)
                {
                    var removeRole = _userManager.RemoveFromRoleAsync(applicationUser, role).Result;
                    var addRole = _userManager.AddToRoleAsync(applicationUser, viewModel.Role).Result;
                    if (viewModel.Role.Equals("Agente") && applicationUser.AgentId == null)
                        viewModel.AgentId = "A" + new Random().Next(999) + new Random().Next(999);
                }
                Mapper.Map(viewModel, applicationUser);
                Edit(applicationUser);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message + " User not found. ");
            }
        }
