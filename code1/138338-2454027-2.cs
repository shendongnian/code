        switch (i % 6)
        {
            case 0:
                minCoordinates.x1 = Math.Min(minCoordinates.x1, allCoordinates[i]);
                break;
            case 1:
                minCoordinates.x2 = Math.Min(minCoordinates.x2, allCoordinates[i]);
                break;
            case 2:
                minCoordinates.y1 = Math.Min(minCoordinates.y1, allCoordinates[i]);
                break;
            case 3:
                minCoordinates.y2 = Math.Min(minCoordinates.y2, allCoordinates[i]);
                break;
            case 4:
                minCoordinates.z1 = Math.Min(minCoordinates.z1, allCoordinates[i]);
                break;
            case 5:
                minCoordinates.z2 = Math.Min(minCoordinates.z2, allCoordinates[i]);
                break;
        }
    }
