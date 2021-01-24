    expression = Expression.And(
                    Expression.Equal(
                        Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Day").Single()),
                        Expression.Constant(searchValue.Day)
                        ),
                    Expression.And(
                        Expression.Equal(
                            Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Month").Single()),
                            Expression.Constant(searchValue.Month)
                            ),
                        Expression.Equal(
                            Expression.MakeMemberAccess(member, typeof(DateTime).GetMember("Year").Single()),
                            Expression.Constant(searchValue.Year)
                            )
                        )
                    );
