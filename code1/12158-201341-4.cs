    Html.ActionLink(article.Title, 
                    "Login",  // <-- Controller Name.
                    "Item",   // <-- ActionMethod
                    new { id = article.ArticleID }, // <-- Route arguments.
                    null  // <-- htmlArguments .. which are none. You need this value
                          //     otherwise you call the WRONG method ...
                          //     (refer to comments, below).
                    )
