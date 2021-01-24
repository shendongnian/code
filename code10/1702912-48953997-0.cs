                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginModel.UserName),
                    new Claim("StaffId", aartsUser.StaffID.ToString())
                };
                // Role Claims
                foreach(Position p in aartsUser.Positions)
                {
                    claims.Add(new Claim(ClaimTypes.Role, p.Role.RoleCd));
                    Claim newClaim = claims.Where(c => c.Value == p.Role.RoleCd).FirstOrDefault();
                    newClaim.Properties.Add("Description", p.Role.RoleName);
                }
