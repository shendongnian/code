            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user == null){ /**/ }
            if (model.smsCode != user.SmsCode){ /**/}
            
            // compute the new hash string
            var newPassword = _userManager.PasswordHasher.HashPassword(user,newpass);
            user.PasswordHash = newPassword;
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded) {/**/}
            else { /**/}
            
