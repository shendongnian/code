    _userRepository.GetAllIncluding(u => u.Claims,
                                    u => u.CreatorUser,
                                    u => u.DeleterUser,
                                    u => u.Roles,
                                    u => u.Department).FirstOrDefault(u => u.Id ==loginResult.User.Id);
