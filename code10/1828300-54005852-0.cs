    A.CallTo(() => testee.Method(
                        A<object>.That.IsNotNull(),
                        A<object[]>.That.IsNull()
                    )
    ).MustHaveHappenedOnceExactly()
    .Then(A.CallTo(() => testee.Method(
                            A<object>.That.IsNotNull(), 
                            A<object[]>.That.Matches(p => p != null && p.Length == 2) //<--
                        )
                  ).MustHaveHappenedOnceExactly()
    );
