    // Create a list to be filtered
    IList<int> elements = new List<int>(new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
    // Filter the list
    int kept = 0;
    for (int i = 0; i < elements.Count; i++) {
        // Test whether this is an element that we want to keep.
        if (elements[i] % 3 > 0) {
            // Add it to the list of kept elements.
            elements[kept] = elements[i];
            kept++;
        }
    }
    // Unfortunately IList has no Resize method. So instead we
    // remove the last element of the list until: elements.Count == kept.
    while (kept < elements.Count) elements.RemoveAt(elements.Count-1);
