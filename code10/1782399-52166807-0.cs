     var result = input.Split(new[] {"\n\n" }, StringSplitOptions.None)
    			.Select(u =>
    			{
    				var user = u.Split(new[] { "\n" }, StringSplitOptions.None);
    				return new User(user[0].Remove(0, 12), user[1].Remove(0, 5), user[2].Remove(0, 7), user[3].Remove(0, 6));
    			});
