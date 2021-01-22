        switch (count % 6)
        {
            case 0:
                minCoordinates.x1 = Math.Min(minCoordinates.x1, item);
                break;
            case 1:
                minCoordinates.x2 = Math.Min(minCoordinates.x2, item);
                break;
            case 2:
                minCoordinates.y1 = Math.Min(minCoordinates.y1, item);
                break;
            case 3:
                minCoordinates.y2 = Math.Min(minCoordinates.y2, item);
                break;
            case 4:
                minCoordinates.z1 = Math.Min(minCoordinates.z1, item);
                break;
            case 5:
                minCoordinates.z2 = Math.Min(minCoordinates.z2, item);
                break;
        }
        count++;
    }
