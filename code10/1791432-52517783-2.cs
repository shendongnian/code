    var autoActivated = builtContainer
                                          .ComponentRegistry
                                          .Registrations
                                          .Where(registration => IsISomething(registration.Activator.LimitType) && registration.Services.Any(i => i.Description.Equals("AutoActivate")))
                                          .ToList();
                    foreach (var iSomethingRegistration in autoActivated)
                    {
                        Console.WriteLine($"Auto activated {string.Join("-", iSomethingRegistration.Services)} ");
                    }
