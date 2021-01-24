    _contactSubscription = _client.ContactManager.CreateSubscription();
    _contactSubscription.Subscribe(ContactSubscriptionRefreshRate.High,
        new[]
            {
                ContactInformationType.ContactEndpoints
            });
                }
                catch (Exception e)
                {
                    Log.WriteLine(e);
                    _mediator.ClientComConnectionDead();
                }
        }
