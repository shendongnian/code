    using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook((character) => { Console.Write(character); });
                Application.Run();
            }
