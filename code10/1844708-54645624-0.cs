var sound = System.Media.SystemSounds.Asterisk;
Console.WriteLine(sound);
var name = "Asterisk";
var soundByName = typeof(System.Media.SystemSounds).GetProperty(name).GetValue(null, null); // null, null because it's a static property
Console.WriteLine(soundByName);
Console.WriteLine(sound == soundByName); // Should output 'true'
