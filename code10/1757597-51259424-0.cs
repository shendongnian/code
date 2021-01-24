                //Given
                var request = new LoginRequest()
                {
                   //filled properties
                };
                var loginResponse = await httpClientGenuineMember.PostAsync("urlToLoginAction", new JsonContent(request));
                AddResponseCookiesToHeaders(httpClientGenuineMember, loginResponse); // THAT LINE MADE THE DIFFERENCE
                AddResponseCookiesToHeaders(httpClientAttacker, loginResponse);
                await httpClientGenuineMember.PostAsync("urlToLogoutAction", new JsonContent(request));
                //When
                var response = await httpClientAttacker.GetAsync("urlToCheckStatusAction");
                //Here the actual result is true
                var actualResult = response.GetResult<bool>();
                //Then
                var expectedResult = false;
