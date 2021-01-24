    foreach(KeyValuePair<int, ColorType> entry in map) {
		if (entry.Key % 2 == 0 && entry.Value == ColorType.Red) { // Even and Red
			map.Remove(entry.Key);
		}
		if (entry.Key % 2 == 1 && entry.Value == ColorType.Yellow) { // Odd and Yellow
			map.Remove(entry.Key);
		}
		
		if (entry.Key % 3 == 0 && entry.Value == ColorType.White) { // Divisible by 3 and White
			map.Remove(entry.Key);
		}
	}
