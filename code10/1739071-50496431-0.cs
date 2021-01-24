    DeviceInformationCustomPairing customPairing = bleDeviceDisplay.DeviceInformation.Pairing.Custom;
                    DevicePairingKinds ceremoniesSelected = DevicePairingKinds.None | DevicePairingKinds.ProvidePin;
                    DevicePairingProtectionLevel protectionLevel = DevicePairingProtectionLevel.None;
                    customPairing.PairingRequested += new TypedEventHandler<DeviceInformationCustomPairing,
                                                          DevicePairingRequestedEventArgs>(CustomPairing_PairingRequested);
                    DevicePairingResult result = await customPairing.PairAsync(ceremoniesSelected,
                                                       protectionLevel);                
    
    
            private void CustomPairing_PairingRequested(DeviceInformationCustomPairing sender, DevicePairingRequestedEventArgs args)
            {
                //this is where your pin goes.
                //windows requires at least a "0".
                args.Accept("000000");//123456
            }
