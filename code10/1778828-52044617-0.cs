 	var userId = HttpContext.Session.GetString("UserId");
            if (!Directory.Exists(Path.Combine(
                        Directory.GetCurrentDirectory(), $"wwwroot/{userId}")))
            {
                Directory.CreateDirectory(Path.Combine(
                        Directory.GetCurrentDirectory(), $"wwwroot/{userId}"));
            }
