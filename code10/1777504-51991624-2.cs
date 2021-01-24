    private void ContactOnContactInformationChanged(object sender, ContactInformationChangedEventArgs e)
    {
        if (e.ChangedContactInformation.Any(_ => _ == ContactInformationType.ContactEndpoints))
        {
            var contactEndpoints = (Contact.GetContactInformation(ContactInformationType.ContactEndpoints) as List<object> ?? new List<object>()).Select(_ => _ as ContactEndpoint).Where(_ => _ != null);
            foreach (var contactEndpoint in contactEndpoints)
            {
                switch (contactEndpoint.Type)
                {
                    case ContactEndpointType.WorkPhone:
                        break;
                    case ContactEndpointType.MobilePhone:
                        break;
                    case ContactEndpointType.HomePhone:
                        break;
                    case ContactEndpointType.OtherPhone:
                        break;
                    case ContactEndpointType.Lync:
                        break;
                    case ContactEndpointType.VoiceMail:
                        break;
                    case ContactEndpointType.Invalid:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
